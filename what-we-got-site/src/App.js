import React, { Component } from 'react';
import axios from 'axios'
import logo from './logo.svg';
import './App.css';
import ToggleButton from './ToggleButton';

class App extends Component {

  constructor(props) {
    super(props);

    this.state = {
      items: []
    }
  }

  componentDidMount(){
    axios.get(`http://localhost:63595/api/ledger`)
    .then(res => {
      const items = res.data;
      console.log(items);
      this.setState({ items });
    })
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <ToggleButton />
        <p className="App-intro">
          To get started, edit <code>src/App.js</code> and save to reload.
          <ul>
            {this.state.items.map(item => {
              return (<li>{item.itemName}</li>)
            })}
          </ul>
        </p>
      </div>
    );
  }
}

export default App;
