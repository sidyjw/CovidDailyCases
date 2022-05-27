import useSWR from "swr"

const API_BASE = !!(process.env.REACT_APP_API_URL_BASE) 
? process.env.REACT_APP_API_URL_BASE: "http://localhost:5000"

interface ResponseBase {
    isLoading: boolean,
    isError: boolean
}
// @ts-ignore: Unreachable code error
const fetcher = (...args: any[]) => fetch(...args).then(res => res.json())

export interface AvailableDates extends ResponseBase {
    dates: string[];
}
export const useAvailableDates = () => {
    const {data, error} = useSWR<string[]>(`${API_BASE}/dates`, fetcher)

    return {
        dates: data,
        isLoading: !error && !data,
        isError: error
    }
}

export interface GetAllCasesAmountByDate extends ResponseBase {
    location: string,
    variantItems: VariantItems[];
}

export interface VariantItems {
    name: string, 
    amount: number
}
export const useGetAllCasesAmountByDate = (stringDateInterval: string | null) => {
    
    const {data, error} = useSWR<GetAllCasesAmountByDate[]>(stringDateInterval && `${API_BASE}/cases/${stringDateInterval}/cumulative`, fetcher)

    return {
        allCasesAmount: data,
        isLoading: !error && !data,
        isError: error
    }
}