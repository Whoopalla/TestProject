import TextField from '@mui/material/TextField';
import React from 'react';
import './ThirdTask.css';
import { isStringPalindrome } from '../HttpClient/Server.js';

export default class ThirdTask extends React.Component {
    constructor(props) {
        super(props);
        this.state = {currentInput: 1, isInputCorrect: true, isInputPalindrome: false};
        
        this.validateInput = this.validateInput.bind(this);
    }

    async isPalindrome(inputString) {
        this.setState({busy: true});
        let result = await isStringPalindrome(inputString.toString());
        return result;
    }

    async validateInput(event) {
        let isInputPalindrome = await this.isPalindrome(event.target.value);
        this.setState({message: (typeof isInputPalindrome.status != undefined && isInputPalindrome.status !== 200 
            ? "Error" : ""), busy: false});

        if (isInputPalindrome.data === true) {
            this.setState({
                isInputCorrect: true
            })
        }
        else {
            this.setState({
                isInputCorrect: false
            })
        }
    }

    render() {
        return <div className='ThirdTask__containder'>
        <h6>{this.props.inputHeader}</h6>
        {this.state.isInputCorrect ? <TextField
            rx={{margin: "1rem auto"}}
            id="mainInput"
            defaultValue="GoooG"
            helperText="Palindrome"
            onChange={this.validateInput}
            />  : <TextField
            rx={{margin: "1rem auto"}}
            error
            id="mainInput"
            defaultValue="GoooG"
            helperText={this.state.isInputCorrect ? "" : "Not a Palindrome"}
            onChange={this.validateInput}
            />
        }
        <h1>{this.state.message}</h1>
    </div>
    }
}