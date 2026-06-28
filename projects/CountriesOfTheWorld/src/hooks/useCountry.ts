import { useQuery } from '@tanstack/react-query'
import { getAllCountries } from '../api/countries'

export function useCountry(code: string) {
  return useQuery({
    queryKey: ['countries'],
    queryFn: getAllCountries,
    staleTime: 1000 * 60 * 10,
    enabled: Boolean(code),
    select: (countries) => countries.find((c) => c.codes.alpha_3 === code),
  })
}
