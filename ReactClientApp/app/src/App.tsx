import logo from './logo.svg';
import './App.css';
import { useState } from 'react';
import ReactTooltip from 'react-tooltip';
import MapChart from './components/MapChart';
function App() {
  const [content, setContent] = useState("");
  return (
    <div>
      <MapChart setTooltipContent={setContent} />
      <ReactTooltip>{content}</ReactTooltip>
    </div> 
  );
}

export default App;
