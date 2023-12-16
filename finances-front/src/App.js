import { Routes, Route } from 'react-router-dom';
import Container from './pages/Container/Container';
import useAuth from "./hooks/useAuth";
import Home from './pages/Home';
import Signin from './pages/Signin';
import Signup from './pages/Signup';
import { AuthProvider } from './contexts/auth';

const Private = ({Item}) => {
  const { signed } = useAuth();
  return signed ? <Container Item={Item} /> : <Signin />;
};

function App() {
  return (
    <AuthProvider>
      <Routes>
        <Route path="/home" element={<Private Item={Home} />} />
        <Route path="/signup" element={<Signup />} />
        <Route path="/" element={<Signin />} />
        <Route path="*" element={<Signin />} />
      </Routes>
    </AuthProvider>
  );
}

export default App;
