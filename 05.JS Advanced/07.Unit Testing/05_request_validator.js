function validator(httpObj) {

    validateMethod(httpObj)
    validateURI(httpObj)
    validateVersion(httpObj)
    validateMessage(httpObj)

    return httpObj

    function validateMethod(httpObj) {
        
        let validMethods = [`GET`, `POST`, `DELETE`, `CONNECT`]

        if (!validMethods.includes(httpObj.method) || 
        httpObj.method === undefined) {
            throw new Error(`Invalid request header: Invalid Method`)
        }
    }

    function validateURI(httpObj) {
        
        let validURIRegex = /^[\w\.]+$|^[\*]$/

        
        if (!validURIRegex.test(httpObj.uri) || 
        httpObj.uri === undefined) {
            throw new Error(`Invalid request header: Invalid URI`)
        }
    }

    function validateVersion(httpObj) {

        let validVersions = [`HTTP/0.9`,`HTTP/1.0`, `HTTP/1.1`, `HTTP/2.0`]
        
        if (!validVersions.includes(httpObj.version) || 
        httpObj.version === undefined) {
            throw new Error(`Invalid request header: Invalid Version`)
        }
    }

    function validateMessage(httpObj) {

        let validMessageRegex = /^[^<>\\&'"]+$|^\s*$/
        
        if (!validMessageRegex.test(httpObj.message) || 
        httpObj.message === undefined) {
            throw new Error(`Invalid request header: Invalid Message`)
        }
    }
}


  console.log(validator({
    method: 'GET',
    uri: 'svn.public.catalog',
    version: 'HTTP/1.1',
    message: '    '
  }));