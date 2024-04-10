package models

// Code generated by xo. DO NOT EDIT.

import (
	"context"
)

// SpConsultaCrear calls the stored procedure 'CaresoftDB.spConsultaCrear(varchar, varchar, varchar, int, varchar, text, decimal, enum('p','r'))' on db.
func SpConsultaCrear(ctx context.Context, db DB, pConsultaCodigo, pDocumentoPaciente, pDocumentoMedico string, pIDConsultorio uint, pMotivo, pComentarios string, pCosto float64, pEstado EnumPR) error {
	// call CaresoftDB.spConsultaCrear
	const sqlstr = `CALL CaresoftDB.spConsultaCrear(?, ?, ?, ?, ?, ?, ?, ?)`
	// run
	logf(sqlstr)
	if _, err := db.ExecContext(ctx, sqlstr, pConsultaCodigo, pDocumentoPaciente, pDocumentoMedico, pIDConsultorio, pMotivo, pComentarios, pCosto, pEstado); err != nil {
		return logerror(err)
	}
	return nil
}
