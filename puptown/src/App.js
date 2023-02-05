import './App.scss';
import { BrowserRouter as Router, Routes,  Route } from 'react-router-dom';
import Navbar from  './components/Navbar';
import Home from './containers/Home'
import Profile from './containers/Profile'
import Landing from './containers/Landing'
import SignIn from './containers/SignIn'
import SignUp from './containers/SignUp'
import Card from './components/postCard'

function App() {
  return (
    <div className='App'>
      <Navbar />
      <Router>
        <Routes>
          <Route exact path="/" element={<Landing/>}/>
          <Route exact path="/home" element={<Home/>}/>
          <Route exact path="/card" element={<Card/>}/>
          <Route exact path="/profile" element={<Profile/>}/>
          <Route exact path="/signIn" element={<SignIn/>}/>
          <Route exact path="/signUp" element={<SignUp/>}/>
        </Routes>
      </Router>
    </div>
  );
}

export default App;
