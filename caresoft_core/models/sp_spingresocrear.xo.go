package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpIngresoCrear calls the stored procedure 'CaresoftDB.spIngresoCrear(varchar, varchar, varchar, varchar, int, int, decimal)' on db.
func SpIngresoCrear(ctx context.Context, db DB, pDocumentoPaciente, pDocumentoEnfermero, pDocumentoMedico, pConsultaCodigo string, pIDAutorizacion, pNumSala uint, pCostoEstancia float64) error {
	// call CaresoftDB.spIngresoCrear
	const sqlstr = `CALL CaresoftDB.spIngresoCrear(?, ?, ?, ?, ?, ?, ?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pDocumentoPaciente, pDocumentoEnfermero, pDocumentoMedico, pConsultaCodigo, pIDAutorizacion, pNumSala, pCostoEstancia); err != nil {
		return logerror(err)
	}
	return nil
}
