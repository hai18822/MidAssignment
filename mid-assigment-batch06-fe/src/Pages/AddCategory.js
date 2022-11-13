import { LockOutlined, UserOutlined } from '@ant-design/icons';
import { Button, Checkbox, Form, Input } from 'antd';
import React from 'react';
import { Link } from 'react-router-dom';

const AddCategory = () => {
    const onFinish = (values) => {
        console.log('Received values of form: ', values);
    };

    return (
        <div className='p-5' style={{
            width: '500px',
            margin: '0 auto',
            
        }}>
            <h3 className='text-center'>Add Category</h3>
            <Form
                name="normal_login"
                className="login-form"
                onFinish={onFinish}
            >
                <Form.Item
                    name="username"
                    rules={[
                        {
                            required: true,
                            message: 'Please input category!',
                        },
                    ]}
                >
                    <Input placeholder="Category name" />
                </Form.Item>
                <Form.Item>
                    <Link to="/su/BookManagement">
                        <Button type="primary" htmlType="submit" className="login-form-button" block>
                            Submit
                        </Button>
                    </Link>
                </Form.Item>
            </Form>
        </div>
    )
}

export default AddCategory;
