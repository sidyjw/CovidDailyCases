import { createContext, useEffect, useState } from "react";
import { useGetAllCasesAmountByDate } from "../apiClient/api";

export interface AppGlobalContext {
    handleDateChange: (initial: string, final: string) => void;
}

export const AppContext = createContext<AppGlobalContext | undefined>(undefined)


export const  AppStorage =  ({
    children,
  }: {
    children: JSX.Element | JSX.Element[];
  })  => {
      const [dateInterval, setDateInterval] = useState<string>("")
      const {allCasesAmount, isError, isLoading} = useGetAllCasesAmountByDate(dateInterval.length > 0 ? dateInterval : null)
      
      useEffect(() => console.log(allCasesAmount), [allCasesAmount])
      
      const handleDateChange = (initial: string, final: string) => {
        setDateInterval(`${initial}~${final}`)
      }
      
      return <AppContext.Provider value={{handleDateChange}}>{children}</AppContext.Provider>
  } 