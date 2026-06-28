export interface CountryNames {
  common: string
  official: string
  native?: Record<string, { common: string; official: string }>
}

export interface CountryFlag {
  url_svg: string
  url_png: string
  description?: string
  emoji?: string
}

export interface CountryCodes {
  alpha_2: string
  alpha_3: string
  ccn3: string
}

export interface CountryCapital {
  name: string
  coordinates?: { lat: number; lng: number }
}

export interface CountryCurrency {
  code: string
  name: string
  symbol: string
}

export interface CountryLanguage {
  name: string
  native_name?: string
  iso639_1?: string
}

export interface CountryLinks {
  google_maps?: string
  open_street_maps?: string
  wikipedia?: string
}

export interface CountrySummary {
  uuid: string
  names: CountryNames
  flag: CountryFlag
  population: number
  region: string
  subregion?: string
  capitals?: CountryCapital[]
  codes: CountryCodes
  borders?: string[]
  continents?: string[]
}

export interface CountryDetail extends CountrySummary {
  tlds?: string[]
  currencies?: CountryCurrency[]
  languages?: CountryLanguage[]
  area?: { kilometers: number; miles: number }
  links?: CountryLinks
}

export type Region = 'Africa' | 'Americas' | 'Asia' | 'Europe' | 'Oceania' | 'Antarctic'

export const REGIONS: Region[] = ['Africa', 'Americas', 'Asia', 'Europe', 'Oceania', 'Antarctic']
