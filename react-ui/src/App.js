import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import './App.css';
import NavBar from './components/NavBar';
import Home from './components/pages/HomePage/Home'
import Footer from './components/pages/Footer/Footer';
import Faceforensics from './components/pages/Faceforensics/Faceforensics';
import Reverse from './components/pages/Reverse/Reverse';
import Keras from './components/pages/Keras/Keras';
import Kerasimg from './components/pages/Kerasimg/Kerasimg';
import Openapi from './components/pages/Openapi/Openapi';

function App() {
  return (
    <>
    <Router>
      <NavBar/>
      <Switch>
        <Route path='/' exact component={Home} />
        <Route path='/faceforensics' component={Faceforensics} />
        <Route path='/reverse' component={Reverse} />
        <Route path='/keras' component={Keras} />
        <Route path='/kerasimg' component={Kerasimg} />
        <Route path='/openapi' component={Openapi} />
      </Switch>
      <Footer />
    </Router>
    </>
  );
}

export default App;
