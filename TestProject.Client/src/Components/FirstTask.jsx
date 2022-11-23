import Button from '@mui/material/Button';
import LoadingButton from '@mui/lab/LoadingButton';
import { Stack } from '@mui/material';
import React from 'react';
import './FirstTask.css';
import EditableList from './EditableList';
import GetArraySum from '../HttpClient/Server';

export default class FirstTask extends React.Component {
    constructor(props) {
        super(props);
        this.state = {isInputCorrect: true, numbersList: new Map(), busy: false, message: ""};

        this.addItemToList = this.addItemToList.bind(this);
        this.removeItemFromList = this.removeItemFromList.bind(this);
        this.getSum = this.getSum.bind(this);
    }

    addItemToList(key, value) {
        this.setState((state) => ({
            numbersList: state.numbersList.set(key, value)
        }));    
    }

    removeItemFromList(key, state) {
        this.setState((state) => ({
            numbersList: (state.numbersList.delete(key) ? state.numbersList : state.numbersList)
        }));
    }

    async getSum() {
        if (this.state.numbersList.size >= 2) {
            this.setState({busy: true});
            const numbers = Array.from(this.state.numbersList.values());
            const result = GetArraySum(numbers);
            result.then(async (result) => this.setState({message: result === undefined ? "Error" : result.data, 
                busy: false}));
        }
    }

    render() {  
      return <Stack  maxWidth="sm" className='firstTask__container-flex'>
            <h1>Abs sum of every second even number</h1>
            <EditableList isLinkedList={false} onDelete={(key) => this.removeItemFromList(key, this.state.numbersList)} 
                onAdd={(key, value) => this.addItemToList(key, value, this.state.numbersList)}
                items={this.state.numbersList}/>
                {this.state.busy ? <LoadingButton onClick={this.getSum} loading variant="contained" sx={{'margin': '3rem'}}>Get Result</LoadingButton>
                    : <Button onClick={this.getSum} variant="contained" sx={{'margin': '3rem'}}>Get Result</Button>}

                <h3>Result: {this.state.message}</h3>
            </Stack>
    }
}