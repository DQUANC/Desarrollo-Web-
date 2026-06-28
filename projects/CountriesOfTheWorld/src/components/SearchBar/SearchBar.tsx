import styles from './SearchBar.module.css'

interface SearchBarProps {
  value: string
  onChange: (value: string) => void
}

export function SearchBar({ value, onChange }: SearchBarProps) {
  return (
    <div className={styles.wrapper}>
      <SearchIcon />
      <label htmlFor="country-search" className={styles.srOnly}>
        Search for a country
      </label>
      <input
        id="country-search"
        type="search"
        className={styles.input}
        placeholder="Search for a country..."
        value={value}
        onChange={(e) => onChange(e.target.value)}
      />
    </div>
  )
}

function SearchIcon() {
  return (
    <svg
      className={styles.icon}
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
      <circle cx="11" cy="11" r="8" />
      <line x1="21" y1="21" x2="16.65" y2="16.65" />
    </svg>
  )
}
