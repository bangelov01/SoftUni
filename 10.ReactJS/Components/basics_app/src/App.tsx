import './App.css';
import Header from "./Components/Header"
import Body from './Components/Body';
import Booklist from './Components/Booklist';
import BookCounter from './Components/BookCounter';

const books : Array<object> = [
  {id:1, title: "Harry Potter", description: "Wizarding stuff"},
  {id:2, title: "Silance of the Lambs", description: "Thriller"},
  {id:3, title: "1948", description: "Apocaliptic"},
  {id:4, description: "Apocaliptic"}
]

function App() {
  return (
    <div>
      <Header>
        <h1>My awesome header!</h1>
        <h2>My second awesome header!</h2>
      </Header>
      <Body/>
      <Booklist books={books}/>
      <BookCounter/>
    </div>
  );
}

export default App;

//test
