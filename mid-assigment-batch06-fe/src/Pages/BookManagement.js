import { Layout, Menu, Table } from 'antd';
import React, { useEffect, useState } from 'react';
import { Link } from 'react-router-dom';
import axios from 'axios';


const columns = [
    {
        title: 'Book ID',
        dataIndex: 'bookId',
        width: 150,
    },
    {
        title: 'Book Title',
        dataIndex: 'bookTitle',
        width: 150,
    },
    {
        title: 'Category',
        dataIndex: 'categoryName',
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

function BookManagement() {
    const [dataBook, setDataBook] = useState([]);

    const getData = () => {
        axios.get('https://localhost:7233/api/book/book')
            .then(function (response) {
                // handle success
                setDataBook(response.data)
                console.log(response.data);
            })
            .catch(function (error) {
                // handle error
                console.log(error);
            })
    }

    const data = dataBook.map((book) => {
        return {
            key: book.bookId,
            bookId: book.bookId,
            bookTitle: book.bookTitle,
            categoryName: book.category.categoryName,
            isDeleted: String(book.isDeleted),
        }
    })

    useEffect(() => {
        getData()
    }, [])
    
    return (
        <div>
            <h1>Book management</h1>
            <button className='btn btn-secondary mb-5'><Link to="addBook">Add Book</Link></button>
            <Table
                columns={columns}
                dataSource={data}
                scroll={{
                    y: 240,
                    x: 1300
                }}
            />
        </div>
    );
};

export default BookManagement;
