import { BrowserRouter as Router, Switch, Route } from 'react-router-dom'
import './App.css';
import NavBar from './components/NavBar';
import Home from './components/pages/HomePage/Home'
import Footer from './components/pages/Footer/Footer';
import Faceforensics from './components/pages/Faceforensics/Faceforensics';
import Reverse from './components/pages/Reverse/Reverse';
import Keras from './components/pages/Keras/Keras';

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
      </Switch>
      <Footer />
    </Router>
    </>
  );
}

export default App;
