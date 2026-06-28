import { useQuery } from '@tanstack/react-query'
import { getAllCountries } from '../api/countries'

export function useBorderCountries(codes: string[] | undefined) {
  return useQuery({
    queryKey: ['countries'],
    queryFn: getAllCountries,
    staleTime: 1000 * 60 * 10,
    enabled: Boolean(codes && codes.length > 0),
    select: (countries) => countries.filter((c) => codes?.includes(c.codes.alpha_3) ?? false),
  })
}
