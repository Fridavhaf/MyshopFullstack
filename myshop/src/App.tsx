import { BrowserRouter as Router, Routes, Route, Navigate } from 'react-router-dom'
import Container from 'react-bootstrap/Container'
import HomePage from './home/HomePage'
import ItemListPage from './items/ItemListPage'
import NavMenu from './shared/NavMenu'
import './App.css'

const App: React.FC = () => {
  return (
    <>
    <NavMenu />
    <Container>
        <Router>
            <Routes>
              <Route path="/" element={<HomePage />} />
              <Route path="/items" element={<ItemListPage />} />
              <Route path="*" element={<Navigate to="/" replace />} />
            </Routes>
        </Router>
    </Container>
    </>
  )
}

export default App