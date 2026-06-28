import { REGIONS } from '../../types/country'
import styles from './RegionFilter.module.css'

interface RegionFilterProps {
  value: string
  onChange: (region: string) => void
}

export function RegionFilter({ value, onChange }: RegionFilterProps) {
  return (
    <div className={styles.wrapper}>
      <label htmlFor="region-filter" className={styles.srOnly}>
        Filter by region
      </label>
      <select
        id="region-filter"
        className={styles.select}
        value={value}
        onChange={(e) => onChange(e.target.value)}
      >
        <option value="">Filter by Region</option>
        {REGIONS.map((region) => (
          <option key={region} value={region}>
            {region}
          </option>
        ))}
      </select>
      <ChevronIcon />
    </div>
  )
}

function ChevronIcon() {
  return (
    <svg
      className={styles.chevron}
      xmlns="http://www.w3.org/2000/svg"
      width="12"
      height="12"
      viewBox="0 0 24 24"
      fill="none"
      stroke="currentColor"
      strokeWidth="2.5"
      strokeLinecap="round"
      strokeLinejoin="round"
      aria-hidden="true"
    >
      <polyline points="6 9 12 15 18 9" />
    </svg>
  )
}
