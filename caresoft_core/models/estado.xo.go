package models

// Code generated by xo. DO NOT EDIT.

import (
	"database/sql/driver"
	"fmt"
)

// Estado is the 'estado' enum type from schema 'CaresoftDB'.
type Estado uint16

// Estado values.
const (
	// EstadoP is the 'P' estado.
	EstadoP Estado = 1
	// EstadoR is the 'R' estado.
	EstadoR Estado = 2
)

// String satisfies the [fmt.Stringer] interface.
func (e Estado) String() string {
	switch e {
	case EstadoP:
		return "P"
	case EstadoR:
		return "R"
	}
	return fmt.Sprintf("Estado(%d)", e)
}

// MarshalText marshals [Estado] into text.
func (e Estado) MarshalText() ([]byte, error) {
	return []byte(e.String()), nil
}

// UnmarshalText unmarshals [Estado] from text.
func (e *Estado) UnmarshalText(buf []byte) error {
	switch str := string(buf); str {
	case "P":
		*e = EstadoP
	case "R":
		*e = EstadoR
	default:
		return ErrInvalidEstado(str)
	}
	return nil
}

// Value satisfies the [driver.Valuer] interface.
func (e Estado) Value() (driver.Value, error) {
	return e.String(), nil
}

// Scan satisfies the [sql.Scanner] interface.
func (e *Estado) Scan(v interface{}) error {
	switch x := v.(type) {
	case []byte:
		return e.UnmarshalText(x)
	case string:
		return e.UnmarshalText([]byte(x))
	}
	return ErrInvalidEstado(fmt.Sprintf("%T", v))
}

// NullEstado represents a null 'estado' enum for schema 'CaresoftDB'.
type NullEstado struct {
	Estado Estado
	// Valid is true if [Estado] is not null.
	Valid bool
}

// Value satisfies the [driver.Valuer] interface.
func (ne NullEstado) Value() (driver.Value, error) {
	if !ne.Valid {
		return nil, nil
	}
	return ne.Estado.Value()
}

// Scan satisfies the [sql.Scanner] interface.
func (ne *NullEstado) Scan(v interface{}) error {
	if v == nil {
		ne.Estado, ne.Valid = 0, false
		return nil
	}
	err := ne.Estado.Scan(v)
	ne.Valid = err == nil
	return err
}

// ErrInvalidEstado is the invalid [Estado] error.
type ErrInvalidEstado string

// Error satisfies the error interface.
func (err ErrInvalidEstado) Error() string {
	return fmt.Sprintf("invalid Estado(%s)", string(err))
}
