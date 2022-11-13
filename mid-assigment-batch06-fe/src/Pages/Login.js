import { LockOutlined, UserOutlined } from '@ant-design/icons';
import { Button, Form, Input } from 'antd';
import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { useForm } from "react-hook-form";
import axios from 'axios';
import { useNavigate } from 'react-router-dom';

const Login = () => {
    const [dataLogin,setDataLogin]=useState()
    const { register, handleSubmit } = useForm();

    const navigate = useNavigate();

    const onSubmit = async(data) =>{

        await axios.post('https://localhost:7233/api/accounts', data)
        .then(function (response) {
            // handle success
            localStorage.setItem("access_token",response.data);
            console.log(response.data)
            navigate('/su')
        })
        .catch(function (error) {
            // handle error
            console.log(error);
            alert('Dang nhap lai!')
        })
    }

    return (
        <div className='p-5' style={{
            width: '500px',
            margin: '100px auto',
            border: '1px solid black'
        }}>
            <h3 className='text-center'>Login</h3>
            <form onSubmit={handleSubmit(onSubmit)}>
                <input {...register("userName")} />
                <input {...register("password")} />
                <input type="submit" />
            </form>
        </div>
    )
}

export default Login;