import type { CountryDetail } from '../types/country'

const BASE_URL = 'https://api.restcountries.com/countries/v5'

class ApiError extends Error {
  status: number
  constructor(status: number, message: string) {
    super(message)
    this.name = 'ApiError'
    this.status = status
  }
}

interface ApiResponse {
  data: { objects: CountryDetail[] }
  meta: { total: number; count: number; limit: number; offset: number; more: boolean } | null
}

function authHeaders(): HeadersInit {
  return { Authorization: `Bearer ${import.meta.env.VITE_API_TOKEN}` }
}

async function fetchJson<T>(url: string): Promise<T> {
  const res = await fetch(url, { headers: authHeaders() })
  if (!res.ok) {
    throw new ApiError(res.status, `API error ${res.status}: ${res.statusText}`)
  }
  return res.json() as Promise<T>
}

export async function getAllCountries(): Promise<CountryDetail[]> {
  const results: CountryDetail[] = []
  let offset = 0
  const limit = 100
  const maxPages = 5

  for (let page = 0; page < maxPages; page++) {
    const data = await fetchJson<ApiResponse>(`${BASE_URL}?limit=${limit}&offset=${offset}`)
    const objects = data.data.objects
    results.push(...objects)
    if (objects.length < limit || data.meta?.more === false) break
    offset += limit
  }

  return results
}
