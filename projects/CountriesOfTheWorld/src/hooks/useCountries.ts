import { useQuery } from '@tanstack/react-query'
import { getAllCountries } from '../api/countries'

export function useCountries() {
  return useQuery({
    queryKey: ['countries'],
    queryFn: getAllCountries,
    staleTime: 1000 * 60 * 10,
  })
}
