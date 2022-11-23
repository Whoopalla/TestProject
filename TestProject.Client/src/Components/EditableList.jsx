import Button from '@mui/material/Button';
import TextField from '@mui/material/TextField';
import { Container } from '@mui/material';
import TrendingFlatIcon from '@mui/icons-material/TrendingFlat';
import React from 'react';
import ListItem from './ListItem.jsx';
import './EditableList.css';

export default class EditableList extends React.Component {
    constructor(props) {
        super(props);
        this.state = {currentInput: 1, isInputCorrect: true};
        
        this.validateInput = this.validateInput.bind(this);
        this.addEventHandler = this.addEventHandler.bind(this);
        this.deleteEventHandler = this.deleteEventHandler.bind(this);
    }

    validateInput(event) {
        if (isNaN(event.target.value) === false) {
            this.setState({
                isInputCorrect: true,
                currentInput: event.target.value
            })
        }
        else {
            this.setState({
                isInputCorrect: false
            })
        }
    }

    addEventHandler(e) {
        if (this.state.isInputCorrect) {
            this.props.onAdd(Date.now(), this.state.currentInput);
        }
    }

    deleteEventHandler(key) {
        this.props.onDelete(key);
    }

    render() {
        const listItems = Array.from(this.props.items).map((item) => {
            return <div key={item[0]} className='EditableList__ListItems_container-flex'>
                <ListItem hashKey={item[0]} value={item[1]}
                    onDelete={(key) => this.deleteEventHandler(item[0])}/>
                {this.props.isLinkedList === true && <TrendingFlatIcon/>}
            </div> 
        })
        return <Container maxWidth="sm">
            <Container>
                <h6>{this.props.inputHeader}</h6>
                {this.state.isInputCorrect ? <TextField
                    id="mainInput"
                    label={this.state.isInputCorrect ? "" : "Error"}
                    defaultValue="1"
                    helperText="Enter a number"
                    onChange={this.validateInput}
                    />  : <TextField
                    error
                    id="mainInput"
                    label={this.state.isInputCorrect ? "" : "Error"}
                    defaultValue="1"
                    helperText={this.state.isInputCorrect ? "" : "Enter a number"}
                    onChange={this.validateInput}
                    />
                }
                <Button onClick={this.addEventHandler} variant="contained" className='EditableList__Form_Btn' sx={{
                    'marginLeft': '0.5rem',
                }}>
                Add
                </Button>
            </Container>
                <div className='EditableList__ListItems_container-flex'>
                    {listItems}
                </div>
        </Container>
    }
}