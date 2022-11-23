import Button from '@mui/material/Button';
import LoadingButton from '@mui/lab/LoadingButton';
import { Stack } from '@mui/material';
import React from 'react';
import './FirstTask.css';
import EditableList from './EditableList';
import {GetTwoLinkedListsSum} from '../HttpClient/Server';
import GetLinkedListFromArray from '../Utils/LinkedListConstructor';
import GetArrayFromLinkedList from '../Utils/LinkedListDestructor';

export default class SecondTask extends React.Component {
    constructor(props) {
        super(props);
        this.state = {isInputCorrect: true, firstNumberList: new Map(),
            secondNumberList: new Map(), busy: false, message: ""};

        this.addItemToFirstList = this.addItemToFirstList.bind(this);
        this.addItemToSecondList = this.addItemToSecondList.bind(this);
        this.removeItemFromFirstList = this.removeItemFromFirstList.bind(this);
        this.removeItemFromSecondList = this.removeItemFromSecondList.bind(this);
        this.getSum = this.getSum.bind(this);
    }

    addItemToFirstList(key, value) {
        this.setState((state) => ({
            firstNumberList: state.firstNumberList.set(key, value)
        }));    
    }

    addItemToSecondList(key, value) {
        this.setState((state) => ({
            secondNumberList: state.secondNumberList.set(key, value)
        }));    
    }

    removeItemFromFirstList(key) {
        this.setState((state) => ({
            firstNumberList: (state.firstNumberList.delete(key) ? state.firstNumberList : state.firstNumberList)
        }));
    }

    removeItemFromSecondList(key) {
        this.setState((state) => ({
            secondNumberList: (state.secondNumberList.delete(key) ? state.secondNumberList : state.secondNumberList)
        }));
    }

    async getSum() {
        if (this.state.firstNumberList.size > 0 && this.state.secondNumberList.size > 0) {
            this.setState({busy: true});
            const firstNumbersList = GetLinkedListFromArray(Array.from(this.state.firstNumberList.values()));
            const secondNumbersList = GetLinkedListFromArray(Array.from(this.state.secondNumberList.values()));
            const result = GetTwoLinkedListsSum(firstNumbersList, secondNumbersList);
            result.then((result) => this.setState({message: result === undefined ? "Error" : GetArrayFromLinkedList(result.data),
                busy: false}));
        }
    }

    render() {  
      return <Stack  maxWidth="sm" className='SecondTask__container-flex'>
            <h1>Adding two numbers as reversed linked lists.</h1>
            <EditableList inputHeader={"First list"} isLinkedList={true} onDelete={(key) => this.removeItemFromFirstList(key, this.state.firstNumberList)} 
                onAdd={(key, value) => this.addItemToFirstList(key, value, this.state.firstNumberList)}
                items={this.state.firstNumberList}/>
            <EditableList inputHeader={"Second list"} isLinkedList={true} onDelete={(key) => this.removeItemFromSecondList(key, this.state.secondNumberList)} 
                onAdd={(key, value) => this.addItemToSecondList(key, value, this.state.secondNumberList)}
                items={this.state.secondNumberList}/>
                
            {this.state.busy ? <LoadingButton onClick={this.getSum} loading variant="contained" 
                sx={{'margin': '3rem'}}>Get Result</LoadingButton>
                : <Button onClick={this.getSum} variant="contained" sx={{'margin': '3rem'}}>Get Result</Button>}
                <h3>Result: {this.state.message}</h3>
            </Stack>
    }
}