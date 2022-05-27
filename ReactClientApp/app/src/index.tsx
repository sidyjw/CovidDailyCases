import ReactDOM from 'react-dom';
import App from './App';
import { ChakraProvider } from "@chakra-ui/react"
import { AppStorage } from './state/AppContext';

ReactDOM.render(
  <AppStorage>
    <ChakraProvider>
      <App />
    </ChakraProvider>
  </AppStorage>
  ,
  document.getElementById('root')
);

