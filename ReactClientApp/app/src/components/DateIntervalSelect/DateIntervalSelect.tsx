import { Box, Center, Flex, Text } from "@chakra-ui/layout";
import { Select } from "@chakra-ui/select";
import { useContext, useState } from "react";
import {useAvailableDates} from "../../apiClient/api";
import { AppContext } from "../../state/AppContext";

const DateIntervalSelect = () => {
    const [initialDate, setInitalDate] = useState<string>("")
    const [finalDate, setFinalDate] = useState<string>("")
    const {dates, isLoading} = useAvailableDates()
    const  context = useContext(AppContext)
    

    const handleChangeInitialDate = (event:React.ChangeEvent<HTMLSelectElement>) => {
        setInitalDate(event.target.value)
        context?.handleDateChange(event.target.value.split('T')[0], event.target.value.split('T')[0]) 
    }
    const handleChangeFinalDate = (event: React.ChangeEvent<HTMLSelectElement>) => {
        setFinalDate(event.target.value)
        context?.handleDateChange(initialDate.split('T')[0], event.target.value.split('T')[0])
    }

    return (
        <>
            <Flex>
                <Box marginRight="25px">
                    <Select placeholder="Início" size="lg" onChange={handleChangeInitialDate}>
                        {!isLoading && dates?.map( date => <option key={date} value={date.split('T')[0]}>{date.split('T')[0]}</option>)}
                    </Select>
                </Box>
                <Center >
                    <Text>Até</Text>
                </Center>
                <Box marginLeft="25px">
                    <Select placeholder="Fim" size="lg" onChange={handleChangeFinalDate} isDisabled={initialDate.length === 0} >
                        {!(initialDate.length === 0) && dates?.filter( date => {
                            const currentDate = new Date(date.split('T')[0]).getTime()
                            const selectedInitialDate = new Date(initialDate).getTime()
                            
                            const filter =  currentDate >= selectedInitialDate
                            return filter 
                        } ).map(date => <option key={date} value={date.split('T')[0]}>{date.split('T')[0]}</option>)}
                    </Select>
                </Box>
            </Flex>
        </>
    )
}

export default DateIntervalSelect;