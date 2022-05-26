import { Box, Center, Flex, Text } from "@chakra-ui/layout";
import { Select } from "@chakra-ui/select";
import { useState } from "react";

const DateIntervalSelect = () => {
    const [initialDate, setInitalDate] = useState<string>("")
    const [finalDate, setFinalDate] = useState<string>("")


    const handleChangeInitialDate = (event:React.ChangeEvent<HTMLSelectElement>) => {
        setInitalDate(event.target.value) 
        console.log("Initial" + event.target.value) 
    }
    const handleChangeFinalDate = (event: React.ChangeEvent<HTMLSelectElement>) => {
        setFinalDate(event.target.value) 
        console.log("Final" + event.target.value) 
    }

    return (
        <>
            <Flex>
                <Box>
                    <Select placeholder="Início" size="lg" onChange={handleChangeInitialDate}>
                        <option value='option1'>Option 11111111111111111111111</option>
                        <option value='option2'>Option 2</option>
                        <option value='option3'>Option 3</option>
                    </Select>
                </Box>
                <Center w="5%">
                    <Text>Até</Text>
                </Center>
                <Box>
                    <Select placeholder="Fim" size="lg" onChange={handleChangeFinalDate} isDisabled={initialDate.length === 0} >
                        <option value='option1'>Option 1</option>
                        <option value='option2'>Option 2</option>
                        <option value='option3'>Option 3</option>
                    </Select>
                </Box>
            </Flex>
        </>
    )
}

export default DateIntervalSelect;