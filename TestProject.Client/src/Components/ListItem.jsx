import Button from '@mui/material/Button';
import CloseIcon from '@mui/icons-material/Close';
import React from 'react';
import '../Resources/close_icon.svg';
import './ListItem.css';

export default class ListItem extends React.Component {
    constructor(props) {
        super(props);
        this.state = {value: props.value, key: props.hashKey};

        this.deleteEventHandler = this.deleteEventHandler.bind(this);
    }

    deleteEventHandler() {
        this.props.onDelete(this.state.key);
    }


    render() {
      return <div className='ListItem__container-flex'>
            <Button onClick={this.deleteEventHandler} variant="contained" endIcon={<CloseIcon />}>
                 {this.state.value}
            </Button>
        </div>
    }
}