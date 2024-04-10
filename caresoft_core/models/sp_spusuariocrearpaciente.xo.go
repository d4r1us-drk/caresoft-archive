package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
	"time"
)

// SpUsuarioCrearPaciente calls the stored procedure 'CaresoftDB.spUsuarioCrearPaciente(varchar, enum('i','p'), varchar, varchar, enum('m','f'), date, varchar, varchar, varchar, varchar, varchar)' on db.
func SpUsuarioCrearPaciente(ctx context.Context, db DB, pDocumento string, pTipoDocumento EnumIP, pNombre, pApellido string, pGenero EnumMF, pFechaNacimiento time.Time, pTelefono, pCorreo, pDireccion, pUsuarioCodigo, pUsuarioContra string) error {
	// call CaresoftDB.spUsuarioCrearPaciente
	const sqlstr = `CALL CaresoftDB.spUsuarioCrearPaciente(?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pDocumento, pTipoDocumento, pNombre, pApellido, pGenero, pFechaNacimiento, pTelefono, pCorreo, pDireccion, pUsuarioCodigo, pUsuarioContra); err != nil {
		return logerror(err)
	}
	return nil
}
