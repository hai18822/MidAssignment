import { Layout, Menu } from 'antd';
import React from 'react';
import { Link, Outlet } from 'react-router-dom';

const { Header, Sider, Content } = Layout;

function LayoutSU() {
    return (
        <Layout>
            <Sider>
                <div className='logo' style={{ padding: '10px 25px' }}>
                    <img style={{
                        width:'100%',
                        height:'50px'
                    }} src='../img/logo.png' alt='logo'/>
                </div>
                <Menu theme="dark"
                    mode="inline">
                    <Menu.Item><Link to="BookManagement">Book management</Link></Menu.Item>
                    <Menu.Item><Link to="CategoryManagement">Category management</Link></Menu.Item>
                </Menu>
            </Sider>
            <Layout className="site-layout">
            <Header className="site-layout-background">
                    <div className='d-flex justify-content-between pt-3'>
                    <h5 style={{ color: '#fff' }}>Library Management Portal</h5>
                    <button className='btn btn-secondary'>Log out</button>
                    </div>
                </Header>
                <Content
                    className="site-layout-background"
                    style={{
                        margin: '24px 16px',
                        padding: 24,
                        minHeight: 1000,
                    }}
                >
                    <Outlet/>
                </Content>
            </Layout>
        </Layout>
    );
};

export default LayoutSU;
