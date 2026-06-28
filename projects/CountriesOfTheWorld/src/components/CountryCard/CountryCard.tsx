import { Link } from 'react-router-dom'
import type { CountrySummary } from '../../types/country'
import styles from './CountryCard.module.css'

interface CountryCardProps {
  country: CountrySummary
}

export function CountryCard({ country }: CountryCardProps) {
  const capital = country.capitals?.[0]?.name ?? 'N/A'
  const population = country.population.toLocaleString()

  return (
    <Link
      to={`/country/${country.codes.alpha_3}`}
      className={styles.card}
      aria-label={`View details for ${country.names.common}`}
    >
      <div className={styles.flag}>
        <img
          src={country.flag.url_svg}
          alt={country.flag.description ?? `Flag of ${country.names.common}`}
          loading="lazy"
          width="320"
          height="200"
        />
      </div>
      <div className={styles.body}>
        <h2 className={styles.name}>{country.names.common}</h2>
        <dl className={styles.details}>
          <div className={styles.row}>
            <dt>Population</dt>
            <dd>{population}</dd>
          </div>
          <div className={styles.row}>
            <dt>Region</dt>
            <dd>{country.region}</dd>
          </div>
          <div className={styles.row}>
            <dt>Capital</dt>
            <dd>{capital}</dd>
          </div>
        </dl>
      </div>
    </Link>
  )
}
