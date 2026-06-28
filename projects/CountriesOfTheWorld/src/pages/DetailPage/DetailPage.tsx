import { useEffect } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { BorderBadge } from '../../components/BorderBadge/BorderBadge'
import { ErrorMessage } from '../../components/ErrorMessage/ErrorMessage'
import { useBorderCountries } from '../../hooks/useBorderCountries'
import { useCountry } from '../../hooks/useCountry'
import styles from './DetailPage.module.css'

export function DetailPage() {
  const { cca3 = '' } = useParams<{ cca3: string }>()
  const navigate = useNavigate()

  const { data: country, isLoading, isError, refetch } = useCountry(cca3)
  const { data: borderCountries } = useBorderCountries(country?.borders)

  useEffect(() => {
    if (country) {
      document.title = `${country.names.common} — Countries of the World`
    }
    return () => {
      document.title = 'Countries of the World'
    }
  }, [country])

  if (isLoading) {
    return (
      <main className={styles.page}>
        <div className={styles.skeleton}>
          <div className={styles.skeletonFlag} />
          <div className={styles.skeletonInfo} />
        </div>
      </main>
    )
  }

  if (isError || !country) {
    return (
      <main className={styles.page}>
        <ErrorMessage
          message="Could not load country details."
          onRetry={() => refetch()}
        />
      </main>
    )
  }

  const nativeName = country.names.native
    ? Object.values(country.names.native)[0]?.common
    : country.names.common

  const currencies = country.currencies?.map((c) => c.name).join(', ') ?? 'N/A'
  const languages = country.languages?.map((c) => c.name).join(', ') ?? 'N/A'
  const capital = country.capitals?.[0]?.name ?? 'N/A'
  const tld = country.tlds?.join(', ') ?? 'N/A'
  const population = country.population.toLocaleString()

  return (
    <main className={styles.page}>
      <button className={styles.back} onClick={() => navigate(-1)} aria-label="Go back">
        <BackIcon />
        Back
      </button>

      <div className={styles.content}>
        <div className={styles.flagWrapper}>
          <img
            src={country.flag.url_svg}
            alt={country.flag.description ?? `Flag of ${country.names.common}`}
            className={styles.flag}
          />
        </div>

        <div className={styles.info}>
          <h1 className={styles.name}>{country.names.common}</h1>

          <div className={styles.details}>
            <dl className={styles.column}>
              <div className={styles.row}>
                <dt>Native Name</dt>
                <dd>{nativeName ?? 'N/A'}</dd>
              </div>
              <div className={styles.row}>
                <dt>Population</dt>
                <dd>{population}</dd>
              </div>
              <div className={styles.row}>
                <dt>Region</dt>
                <dd>{country.region}</dd>
              </div>
              <div className={styles.row}>
                <dt>Sub Region</dt>
                <dd>{country.subregion ?? 'N/A'}</dd>
              </div>
              <div className={styles.row}>
                <dt>Capital</dt>
                <dd>{capital}</dd>
              </div>
            </dl>

            <dl className={styles.column}>
              <div className={styles.row}>
                <dt>Top Level Domain</dt>
                <dd>{tld}</dd>
              </div>
              <div className={styles.row}>
                <dt>Currencies</dt>
                <dd>{currencies}</dd>
              </div>
              <div className={styles.row}>
                <dt>Languages</dt>
                <dd>{languages}</dd>
              </div>
            </dl>
          </div>

          {country.borders && country.borders.length > 0 && (
            <div className={styles.borders}>
              <h2 className={styles.bordersTitle}>Border Countries:</h2>
              <div className={styles.badgeList}>
                {borderCountries
                  ? borderCountries.map((b) => (
                      <BorderBadge key={b.codes.alpha_3} name={b.names.common} cca3={b.codes.alpha_3} />
                    ))
                  : country.borders.map((code) => (
                      <BorderBadge key={code} name={code} cca3={code} />
                    ))}
              </div>
            </div>
          )}
        </div>
      </div>
    </main>
  )
}

function BackIcon() {
  return (
    <svg
      xmlns="http://www.w3.org/2000/svg"
      width="16"
      height="16"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      strokeWidth="2"
      strokeLinecap="round"
      strokeLinejoin="round"
      aria-hidden="true"
    >
      <line x1="19" y1="12" x2="5" y2="12" />
      <polyline points="12 19 5 12 12 5" />
    </svg>
  )
}
