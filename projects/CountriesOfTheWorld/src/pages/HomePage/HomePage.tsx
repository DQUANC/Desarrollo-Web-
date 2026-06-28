import { useState } from 'react'
import { CountryCard } from '../../components/CountryCard/CountryCard'
import { ErrorMessage } from '../../components/ErrorMessage/ErrorMessage'
import { LoadingGrid } from '../../components/LoadingGrid/LoadingGrid'
import { RegionFilter } from '../../components/RegionFilter/RegionFilter'
import { SearchBar } from '../../components/SearchBar/SearchBar'
import { useCountries } from '../../hooks/useCountries'
import { useFilteredCountries } from '../../hooks/useFilteredCountries'
import styles from './HomePage.module.css'

export function HomePage() {
  const [query, setQuery] = useState('')
  const [region, setRegion] = useState('')

  const { data: countries, isLoading, isError, refetch } = useCountries()
  const filtered = useFilteredCountries(countries, query, region)

  return (
    <main className={styles.page}>
      <div className={styles.toolbar}>
        <SearchBar value={query} onChange={setQuery} />
        <RegionFilter value={region} onChange={setRegion} />
      </div>

      {isLoading && <LoadingGrid />}

      {isError && (
        <ErrorMessage
          message="Could not load countries. Check your connection and try again."
          onRetry={() => refetch()}
        />
      )}

      {!isLoading && !isError && filtered.length === 0 && (
        <div className={styles.empty}>
          <p>No countries found{query ? ` for "${query}"` : ''}.</p>
        </div>
      )}

      {!isLoading && !isError && filtered.length > 0 && (
        <div className={styles.grid}>
          {filtered.map((country) => (
            <CountryCard key={country.codes.alpha_3} country={country} />
          ))}
        </div>
      )}
    </main>
  )
}
