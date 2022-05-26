import { useState } from 'react';
import ReactTooltip from 'react-tooltip';
import DateIntervalSelect from './components/DateIntervalSelect/DateIntervalSelect';
import MapChart from './components/MapChart';

function App() {
  const [content, setContent] = useState("");
  return (
    <div>
      <DateIntervalSelect />
      <MapChart setTooltipContent={setContent} />
      <ReactTooltip html={true}>{content}</ReactTooltip>
    </div> 
  );
}

export default App;
