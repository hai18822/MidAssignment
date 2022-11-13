import { Button, Checkbox, Form, Input } from 'antd';
import React from 'react';
import { Link } from 'react-router-dom';

const AddBook = () => {
    const onFinish = (values) => {
        console.log('Received values of form: ', values);
    };

    return (
        <div className='p-5' style={{
            width: '500px',
            margin: '0 auto',
        }}>
            <h3 className='text-center'>Add Book</h3>
        </div>
    )
}

export default AddBook;
