import React, { Component } from 'react'
import axios from 'axios'

// http://images.ctfassets.net/hrltx12pl8hq/7yQR5uJhwEkRfjwMFJ7bUK/dc52a0913e8ff8b5c276177890eb0129/offset_comp_772626-opt.jpg?fit=fill&w=800&h=300
class PostForm extends Component {
    constructor(props){
        super(props)

        this.state = {
            image_path: ''
        }
    }

    changeHandler=(e)  =>{
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    submitHandler = (e) => {
        e.preventDefault()

        fetch("http://localhost:8081/reverse", {
            "method": "POST",
            "headers": {
                "content-type": "application/json",
                "accept": "application/json",
                "Access-Control-Allow-Origin": "*"
            },
            "body": JSON.stringify({
                image_path: this.state.image_path,
            })
        })
        .then(response => response.json())
        .then(response => {
            console.log(response)
        })
        .catch(err => {
            console.log(err);
        });
    }

    render() {
        const { image_path } = this.state
        return (
            <div>
                <form onSubmit={this.submitHandler}>
                <div>
                    <input 
                    type='text' 
                    name ='image_path' 
                    onChange={this.changeHandler}
                    value={image_path}></input>
                </div>

                <button type='submit'>Submit Now</button>
                </form>
            </div>
        )
    }
}

export default PostForm
