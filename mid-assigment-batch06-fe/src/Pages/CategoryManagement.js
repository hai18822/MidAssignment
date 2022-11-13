import { Table } from 'antd';
import axios from 'axios';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';

const columns = [
    {
        title: 'Category Id',
        dataIndex: 'categoryId',
        width: 150,
    },
    {
        title: 'Category Name',
        dataIndex: 'categoryName',
        width: 150,
    },
    {
        title: 'Deleted',
        dataIndex: 'isDeleted',
    },
    {
        title: 'Action',
        render: () => {
            return <>
                <button className='btn btn-warning mr-2'>Edit</button>
                <button className='btn btn-danger'>Delete</button>
            </>
        }
    },
];



function CategoryManagement() {
    const [categories, setCategories] = useState([]);

    const getData = () => {
        axios.get('https://localhost:7233/api/category')
            .then(function (response) {
                // handle success
                setCategories(response.data)
                console.log(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
    }
    const data = categories.map((cat) => {
        return {
            key: cat.categoryId,
            categoryId: cat.categoryId,
            categoryName: cat.categoryName,
            isDeleted: String(cat.isDeleted),
        }
    })

    useEffect(() => {
        getData()
    }, [])
    return (
        <div>
            <h1>Category management</h1>
            <button className='btn btn-success mb-5'><Link to="addCat">Add Category</Link></button>
            <Table
                columns={columns}
                dataSource={data}
                pagination={false}
                scroll={{
                    y: 240,
                    x:1300
                }}
            />
        </div>
    );
};

export default CategoryManagement;
