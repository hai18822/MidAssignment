import './App.css';
import 'antd/dist/antd.css';
import {
  Routes,
  Route
} from 'react-router-dom';
import Login from './Pages/Login';
import BookManagement from './Pages/BookManagement';
import CategoryManagement from './Pages/CategoryManagement';
import LayoutSU from './Pages/LayoutSU';
import AddCategory from './Pages/AddCategory';
import AddBook from './Pages/AddBook';

function App() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="/su" element={<LayoutSU />} >
        <Route index element={<BookManagement />} />
        <Route path="BookManagement" element={<BookManagement />} />
        <Route path="CategoryManagement" element={<CategoryManagement />} />
        <Route path="CategoryManagement/addCat" element={<AddCategory />} />
        <Route path="BookManagement/addBook" element={<AddBook />} />
      </Route>
    </Routes>
  );
}

export default App;
