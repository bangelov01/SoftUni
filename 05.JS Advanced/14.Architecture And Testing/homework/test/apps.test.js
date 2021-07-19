const { chromium } = require('playwright-chromium');

const { expect } = require('chai');

//START LIVE SERVER BEFORE TESTING

let browser, page;
let messagesUrl = 'http://127.0.0.1:5500/01.Messenger/index.html';
let booksUrl = 'http://127.0.0.1:5500/02.Book-library/index.html';

function mockJson(data) {
    return {
        status: 200,
        headers: {
            'Access-Control-Allow-Origin': '*',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(data)
    };
}


const testMessages = {
    1: {
        author: 'Misho',
        content: 'MishoMessage'
    },
    2: {
        author: 'Gosho',
        content: 'GoshoMessage'
    },
}

const createMessage = {
    1: {
        author: 'Dido',
        content: 'DidoMessage',
        _id: 2
    }
}

const testBooks = {
    1: {
        title: '1984',
        author: 'George Orwell',
        _id: '1'
    },  
}

const createBook = {
    1: {
        title: 'King Rat',
        author: 'James Clavell'
    },
}

describe('Tests/browser config', function () {
this.timeout(6000)
    //headless: false, slowMo: 500
    before(async () => { browser = await chromium.launch(); });

    after(async () => { await browser.close(); });

    beforeEach(async () => { page = await browser.newPage(); });

    afterEach(async () => { await page.close(); });

    describe('Messanger Tests', () => {

        describe('Load messages', () => {
        
            it('Should load messages from server and put in textbox', async () => {
    
                await page.route('**/jsonstore/messenger', route => { route.fulfill(mockJson(testMessages)) });
    
                await page.goto(messagesUrl);
    
                const [response] = await Promise.all([
                    page.waitForResponse('**/jsonstore/messenger'),
                    page.click('#refresh'),
                ]);
    
                const result = await response.json();
    
                const expectedTextbox = Object.values(result).map(msg => `${msg.author}: ${msg.content}`).join(`\n`);
                const actualTextBox = await page.textContent('#messages');
    
                expect(result).to.eql(testMessages);
                expect(expectedTextbox).to.equal(actualTextBox);
            })
        })
    
        describe('Send messages', () => {

            it('Should send messages to server', async () => {
                let requestData;
                const expected = {
                    author: 'Dido',
                    content: 'DidoMessage',
                }
                await page.route('**/jsonstore/messenger', (route, request) => {
                    if (request.method().toLowerCase() === 'post') {
                        requestData = request.postData();
                        route.fulfill(mockJson(createMessage));
                    }
                });
    
                await page.goto(messagesUrl);
                await page.fill('input[name=author]', expected.author)
                await page.fill('input[name=content]', expected.content)
    
                const [response] = await Promise.all([
                    page.waitForResponse('**/jsonstore/messenger'),
                    page.click('#submit'),
                ]);
    
                const result = JSON.parse(requestData)
                expect(result).to.eql(expected);
            });
        })
    });

    describe('Booklibrary Tests', () => {

        describe('Load books', () => {
            it('Should load book from server when Load All Books is pressed', async() => {

                await page.route('**/jsonstore/collections/books/', route => { route.fulfill(mockJson(testBooks)) });
    
                await page.goto(booksUrl);
    
                const [response] = await Promise.all([
                    page.waitForResponse('**/jsonstore/collections/books/'),
                    page.click('#loadBooks'),
                ]);

                const result = await response.json();

                const [title, author] = await Promise.all([
                    page.textContent('tbody tr td'),
                    page.textContent('tbody tr td:nth-child(2)'),
                ]);

                expect(Object.values(result)[0].title).to.equal(title);
                expect(Object.values(result)[0].author).to.equal(author);
                expect(result).to.eql(testBooks);
            });
        });

        describe('Send books', () => {
            it('Should send data to server when Submit is pressed', async() => {
                let requestData;
                const expected = {
                    title: 'King Rat',
                    author: 'James Clavell',
                }
                await page.route('**/jsonstore/collections/books/', (route, request) => {
                    if (request.method().toLowerCase() === 'post') {
                        requestData = request.postData();
                        route.fulfill(mockJson(createBook));
                    }
                });
    
                await page.goto(booksUrl);
                await page.fill('#main-form input[name=title]', expected.title)
                await page.fill('#main-form input[name=author]', expected.author)
    
                const [response] = await Promise.all([
                    page.waitForResponse('**/jsonstore/collections/books/'),
                    page.click('#main-form button'),
                ]);
    
                const result = JSON.parse(requestData)
                expect(result).to.eql(expected);
            });

            it('Should throw alert when fields are empty', async() => {

                await page.goto(booksUrl);
                await page.click('#main-form button');

                page.on('dialog', async dialog => {
                    expect(dialog.type()).to.equal('alert');
                    expect(dialog.message()).to.equal('Fields must not be empty!');
                    await dialog.dismiss();
                });
            });
        });

        describe('Edit books', () => {
            it('Should fill form fields when Edit is pressed', async() => {
                await page.route('**/jsonstore/collections/books/', route => { route.fulfill(mockJson(testBooks)) });
    
                await page.goto(booksUrl);


                await page.click('#loadBooks');

                const [title, author] = await Promise.all([
                    page.textContent('tbody tr td'),
                    page.textContent('tbody tr td:nth-child(2)'),
                ]);

                await page.click('#editBtn');
                const isEditVisible = await page.isVisible('#edit-form');

                const titleInput = await page.$eval('#edit-form input[name=title]', el => el.value);
                const authorInput = await page.$eval('#edit-form input[name=author]', el => el.value);

                expect(isEditVisible).to.be.true;
                expect(titleInput).to.be.equal(title);
                expect(authorInput).to.be.equal(author);

            });

            it('Should update book when submit is pressed', async() => {
                const example = {
                    title: 'test',
                    author: 'test'
                }
                await page.route('**/jsonstore/collections/books/', request => {
                    request.fulfill(mockJson(testBooks))
                })
                await page.route(
                    '**/jsonstore/collections/books/*',
                    request => request.fulfill(mockJson(example))
                )

                await page.goto(booksUrl);
    
                await page.click('#loadBooks')
                await page.click('#editBtn')
    
    
                const [response] = await Promise.all([
                    page.waitForResponse(r => r.request().url()
                        .includes('/jsonstore/collections/books/') && r.request().method() === 'PUT'),
                    page.click('text="Save"')
                ])
                const result = JSON.parse(await response.body())
                expect(result).to.eql(example);
            });

            it('Should delete book when delete is pressed', async() => {

                const example = {
                    text: 'deleted'
                };
                await page.route('**/jsonstore/collections/books/', request => {
                    request.fulfill(mockJson(testBooks))
                })
                await page.route(
                    '**/jsonstore/collections/books/*',
                    request => request.fulfill(mockJson(example))
                )

                await page.goto(booksUrl);
    
                await page.click('#loadBooks')
                await page.click('#editBtn')
    
    
                const [response] = await Promise.all([
                    page.waitForResponse(r => r.request().url()
                        .includes('/jsonstore/collections/books/') && r.request().method() === 'DELETE'),
                    page.click('#deleteBtn')
                ])
                const result = JSON.parse(await response.body())
                expect(result).to.eql(example);
            });
        });
    });
});