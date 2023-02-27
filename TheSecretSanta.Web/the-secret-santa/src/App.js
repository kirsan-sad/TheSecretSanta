import HomePage from "./pages/HomePage/HomePage";
import { Routes, Route } from 'react-router-dom';

function App() {
  return (
    <div className="w-screen h-full min-h-screen text-neutral-700 bg-slate-50">
      <Routes>
        <Route path='/' element={<HomePage/>} />
      </Routes>
    </div>
  );
}

export default App;
