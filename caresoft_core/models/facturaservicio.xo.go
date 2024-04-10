package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
	"database/sql"
)

// FacturaServicio represents a row from 'CaresoftDB.Factura_Servicio'.
type FacturaServicio struct {
	FacturaCodigo  string         `json:"facturaCodigo"`  // facturaCodigo
	ServicioCodigo string         `json:"servicioCodigo"` // servicioCodigo
	IDAutorizacion sql.NullInt64  `json:"idAutorizacion"` // idAutorizacion
	Resultados     sql.NullString `json:"resultados"`     // resultados
	Costo          float64        `json:"costo"`          // costo
	// xo fields
	_exists, _deleted bool
}

// Exists returns true when the [FacturaServicio] exists in the database.
func (fs *FacturaServicio) Exists() bool {
	return fs._exists
}

// Deleted returns true when the [FacturaServicio] has been marked for deletion
// from the database.
func (fs *FacturaServicio) Deleted() bool {
	return fs._deleted
}

// Insert inserts the [FacturaServicio] to the database.
func (fs *FacturaServicio) Insert(ctx context.Context, db DB) error {
	switch {
	case fs._exists: // already exists
		return logerror(&ErrInsertFailed{ErrAlreadyExists})
	case fs._deleted: // deleted
		return logerror(&ErrInsertFailed{ErrMarkedForDeletion})
	}
	// insert (manual)
	const sqlstr = `INSERT INTO CaresoftDB.Factura_Servicio (` +
		`facturaCodigo, servicioCodigo, idAutorizacion, resultados, costo` +
		`) VALUES (` +
		`?, ?, ?, ?, ?` +
		`)`
	// run
	logf(sqlstr, fs.FacturaCodigo, fs.ServicioCodigo, fs.IDAutorizacion, fs.Resultados, fs.Costo)
	if _, err := db.ExecContext(ctx, sqlstr, fs.FacturaCodigo, fs.ServicioCodigo, fs.IDAutorizacion, fs.Resultados, fs.Costo); err != nil {
		return logerror(err)
	}
	// set exists
	fs._exists = true
	return nil
}

// Update updates a [FacturaServicio] in the database.
func (fs *FacturaServicio) Update(ctx context.Context, db DB) error {
	switch {
	case !fs._exists: // doesn't exist
		return logerror(&ErrUpdateFailed{ErrDoesNotExist})
	case fs._deleted: // deleted
		return logerror(&ErrUpdateFailed{ErrMarkedForDeletion})
	}
	// update with primary key
	const sqlstr = `UPDATE CaresoftDB.Factura_Servicio SET ` +
		`idAutorizacion = ?, resultados = ?, costo = ? ` +
		`WHERE facturaCodigo = ? AND servicioCodigo = ?`
	// run
	logf(sqlstr, fs.IDAutorizacion, fs.Resultados, fs.Costo, fs.FacturaCodigo, fs.ServicioCodigo)
	if _, err := db.ExecContext(ctx, sqlstr, fs.IDAutorizacion, fs.Resultados, fs.Costo, fs.FacturaCodigo, fs.ServicioCodigo); err != nil {
		return logerror(err)
	}
	return nil
}

// Save saves the [FacturaServicio] to the database.
func (fs *FacturaServicio) Save(ctx context.Context, db DB) error {
	if fs.Exists() {
		return fs.Update(ctx, db)
	}
	return fs.Insert(ctx, db)
}

// Upsert performs an upsert for [FacturaServicio].
func (fs *FacturaServicio) Upsert(ctx context.Context, db DB) error {
	switch {
	case fs._deleted: // deleted
		return logerror(&ErrUpsertFailed{ErrMarkedForDeletion})
	}
	// upsert
	const sqlstr = `INSERT INTO CaresoftDB.Factura_Servicio (` +
		`facturaCodigo, servicioCodigo, idAutorizacion, resultados, costo` +
		`) VALUES (` +
		`?, ?, ?, ?, ?` +
		`)` +
		` ON DUPLICATE KEY UPDATE ` +
		`facturaCodigo = VALUES(facturaCodigo), servicioCodigo = VALUES(servicioCodigo), idAutorizacion = VALUES(idAutorizacion), resultados = VALUES(resultados), costo = VALUES(costo)`
	// run
	logf(sqlstr, fs.FacturaCodigo, fs.ServicioCodigo, fs.IDAutorizacion, fs.Resultados, fs.Costo)
	if _, err := db.ExecContext(ctx, sqlstr, fs.FacturaCodigo, fs.ServicioCodigo, fs.IDAutorizacion, fs.Resultados, fs.Costo); err != nil {
		return logerror(err)
	}
	// set exists
	fs._exists = true
	return nil
}

// Delete deletes the [FacturaServicio] from the database.
func (fs *FacturaServicio) Delete(ctx context.Context, db DB) error {
	switch {
	case !fs._exists: // doesn't exist
		return nil
	case fs._deleted: // deleted
		return nil
	}
	// delete with composite primary key
	const sqlstr = `DELETE FROM CaresoftDB.Factura_Servicio ` +
		`WHERE facturaCodigo = ? AND servicioCodigo = ?`
	// run
	logf(sqlstr, fs.FacturaCodigo, fs.ServicioCodigo)
	if _, err := db.ExecContext(ctx, sqlstr, fs.FacturaCodigo, fs.ServicioCodigo); err != nil {
		return logerror(err)
	}
	// set deleted
	fs._deleted = true
	return nil
}

// FacturaServicioByFacturaCodigoServicioCodigo retrieves a row from 'CaresoftDB.Factura_Servicio' as a [FacturaServicio].
//
// Generated from index 'Factura_Servicio_facturaCodigo_servicioCodigo_pkey'.
func FacturaServicioByFacturaCodigoServicioCodigo(ctx context.Context, db DB, facturaCodigo, servicioCodigo string) (*FacturaServicio, error) {
	// query
	const sqlstr = `SELECT ` +
		`facturaCodigo, servicioCodigo, idAutorizacion, resultados, costo ` +
		`FROM CaresoftDB.Factura_Servicio ` +
		`WHERE facturaCodigo = ? AND servicioCodigo = ?`
	// run
	logf(sqlstr, facturaCodigo, servicioCodigo)
	fs := FacturaServicio{
		_exists: true,
	}
	if err := db.QueryRowContext(ctx, sqlstr, facturaCodigo, servicioCodigo).Scan(&fs.FacturaCodigo, &fs.ServicioCodigo, &fs.IDAutorizacion, &fs.Resultados, &fs.Costo); err != nil {
		return nil, logerror(err)
	}
	return &fs, nil
}

// FacturaServicioByIDAutorizacion retrieves a row from 'CaresoftDB.Factura_Servicio' as a [FacturaServicio].
//
// Generated from index 'idAutorizacion'.
func FacturaServicioByIDAutorizacion(ctx context.Context, db DB, idAutorizacion sql.NullInt64) (*FacturaServicio, error) {
	// query
	const sqlstr = `SELECT ` +
		`facturaCodigo, servicioCodigo, idAutorizacion, resultados, costo ` +
		`FROM CaresoftDB.Factura_Servicio ` +
		`WHERE idAutorizacion = ?`
	// run
	logf(sqlstr, idAutorizacion)
	fs := FacturaServicio{
		_exists: true,
	}
	if err := db.QueryRowContext(ctx, sqlstr, idAutorizacion).Scan(&fs.FacturaCodigo, &fs.ServicioCodigo, &fs.IDAutorizacion, &fs.Resultados, &fs.Costo); err != nil {
		return nil, logerror(err)
	}
	return &fs, nil
}

// FacturaServicioByServicioCodigo retrieves a row from 'CaresoftDB.Factura_Servicio' as a [FacturaServicio].
//
// Generated from index 'servicioCodigo'.
func FacturaServicioByServicioCodigo(ctx context.Context, db DB, servicioCodigo string) ([]*FacturaServicio, error) {
	// query
	const sqlstr = `SELECT ` +
		`facturaCodigo, servicioCodigo, idAutorizacion, resultados, costo ` +
		`FROM CaresoftDB.Factura_Servicio ` +
		`WHERE servicioCodigo = ?`
	// run
	logf(sqlstr, servicioCodigo)
	rows, err := db.QueryContext(ctx, sqlstr, servicioCodigo)
	if err != nil {
		return nil, logerror(err)
	}
	defer rows.Close()
	// process
	var res []*FacturaServicio
	for rows.Next() {
		fs := FacturaServicio{
			_exists: true,
		}
		// scan
		if err := rows.Scan(&fs.FacturaCodigo, &fs.ServicioCodigo, &fs.IDAutorizacion, &fs.Resultados, &fs.Costo); err != nil {
			return nil, logerror(err)
		}
		res = append(res, &fs)
	}
	if err := rows.Err(); err != nil {
		return nil, logerror(err)
	}
	return res, nil
}

// Factura returns the Factura associated with the [FacturaServicio]'s (FacturaCodigo).
//
// Generated from foreign key 'Factura_Servicio_ibfk_1'.
func (fs *FacturaServicio) Factura(ctx context.Context, db DB) (*Factura, error) {
	return FacturaByFacturaCodigo(ctx, db, fs.FacturaCodigo)
}

// Servicio returns the Servicio associated with the [FacturaServicio]'s (ServicioCodigo).
//
// Generated from foreign key 'Factura_Servicio_ibfk_2'.
func (fs *FacturaServicio) Servicio(ctx context.Context, db DB) (*Servicio, error) {
	return ServicioByServicioCodigo(ctx, db, fs.ServicioCodigo)
}

// Autorizacion returns the Autorizacion associated with the [FacturaServicio]'s (IDAutorizacion).
//
// Generated from foreign key 'Factura_Servicio_ibfk_3'.
func (fs *FacturaServicio) Autorizacion(ctx context.Context, db DB) (*Autorizacion, error) {
	return AutorizacionByIDAutorizacion(ctx, db, uint(fs.IDAutorizacion.Int64))
}
