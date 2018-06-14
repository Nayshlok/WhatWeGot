import React from 'react';

export default class ToggleButton extends React.Component {
    constructor(props){
        super(props);
        this.state = {
            isToggled: false
        }

        this.toggleButton = this.toggleButton.bind(this);
    }

    toggleButton(event) {
        this.setState((oldState) => {
           return {isToggled: !oldState.isToggled}
        })
    }

    render(){
        return (
            <button onClick={this.toggleButton}>
                {this.state.isToggled ? 'X' : 'O'}
            </button>
        )
    }
}