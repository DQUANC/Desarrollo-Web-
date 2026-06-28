import { useMemo } from 'react'
import type { CountrySummary } from '../types/country'

export function useFilteredCountries(
  countries: CountrySummary[] | undefined,
  query: string,
  region: string,
): CountrySummary[] {
  return useMemo(() => {
    if (!countries) return []
    let result = countries
    if (region) {
      result = result.filter((c) => c.region === region)
    }
    if (query.trim()) {
      const q = query.trim().toLowerCase()
      result = result.filter((c) => c.names.common.toLowerCase().includes(q))
    }
    return result
  }, [countries, query, region])
}
