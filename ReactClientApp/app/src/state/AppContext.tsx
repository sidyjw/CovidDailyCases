import { createContext, useState } from "react";
import { GetAllCasesAmountByDate, useGetAllCasesAmountByDate } from "../apiClient/api";

export interface AppGlobalContext {
    handleDateChange: (initial: string, final: string) => void;
    allCasesAmount: GetAllCasesAmountByDate[] | undefined
}

export const AppContext = createContext<AppGlobalContext | undefined>(undefined)


export const  AppStorage =  ({
    children,
  }: {
    children: JSX.Element | JSX.Element[];
  })  => {
      const [dateInterval, setDateInterval] = useState<string>("")
      const {allCasesAmount} = useGetAllCasesAmountByDate(dateInterval.length > 0 ? dateInterval : null)
      
      const handleDateChange = (initial: string, final: string) => {
        setDateInterval(`${initial}~${final}`)
      }
      
      return <AppContext.Provider value={{handleDateChange, allCasesAmount}}>{children}</AppContext.Provider>
  } 