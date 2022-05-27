import { Box, Center, SimpleGrid, Text } from '@chakra-ui/layout';
import { useState } from 'react';
import ReactTooltip from 'react-tooltip';
import DateIntervalSelect from './components/DateIntervalSelect/DateIntervalSelect';
import MapChart from './components/MapChart';

function App() {
  const [content, setContent] = useState("");
  return (
    <Box p="10px 25px">
      <SimpleGrid columns={1} spacing={5} >
        <Box>
          <Center>
            <Text fontSize='6xl'>Covid Daily Cases</Text>
          </Center>
        </Box>
        <Box>
          <Center>
            <DateIntervalSelect />
          </Center>
        </Box>
        <Box>
          <Center>
            <Box w="100%" maxWidth="55rem">
              <MapChart setTooltipContent={setContent}/>
              <ReactTooltip html={true} multiline={true} place={"right"}>{content}</ReactTooltip>
            </Box>
          </Center>
        </Box>
      </SimpleGrid>
    </Box> 
  );
}

export default App;
