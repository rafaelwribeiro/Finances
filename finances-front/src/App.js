import { Routes, Route } from 'react-router-dom';
import Home from './pages/Home';
import Signein from './pages/Signein';
import GlobalStyle from './styles/global';

const Private = ({Item}) => {
  const signed = false;
  return signed ? <Item /> : <Signein />;
};

function App() {
  return (
    <>
      <h1>Teste</h1>
      <Routes>
        <Route path="/home" element={<Private Item={Home} />} />
        <Route path="*" element={<Signein />} />
      </Routes>
      <GlobalStyle />
    </>
  );
}

export default App;
