﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

/// <summary>
/// Summary description for EdicaoBLL
/// </summary>
public class EdicaoBLL
{
    private EdicaoDAL edi;

	public EdicaoBLL()
	{
        edi = new EdicaoDAL();
	}

    public List<TextoEdit> getLista(int ordenacao)
    {
        List<TextoEdit> lista = new List<TextoEdit>();

        DataTable dt = edi.select(ordenacao);

        foreach (DataRow row in dt.Rows)
        {

            TextoEdit text =
                new TextoEdit((int)row[0],               // idTexto
                             row[1].ToString(),          // Titulo
                             row[2].ToString(),          // Texto
                             row[3].ToString(),          // Intro
                             row[4].ToString(),          // user
                             row[5].ToString(),          // link
                             Convert.ToDateTime(row[6]), // Data Acesso
                             Convert.ToDateTime(row[7])  // Data Mod
                             );
            lista.Add(text);
        }
        return lista;
    }

    public TextoEdit getTexto(int idTexto)
    {
        DataRow row = edi.pesquisaID(idTexto);

        return (new TextoEdit((int)row[0],               // idTexto
                             row[1].ToString(),          // Titulo
                             row[2].ToString(),          // Texto
                             row[3].ToString(),          // Intro
                             row[4].ToString(),          // user
                             row[5].ToString(),          // link
                             Convert.ToDateTime(row[6]), // Data Acesso
                             Convert.ToDateTime(row[7])  // Data Mod
                            ));
    }

    public void saveTexto(int idTexto, string texto, string titulo)
    {
        edi.updateTexto(idTexto, texto, titulo);
    }

    public void archiveTexto(int idTexto, string texto, string titulo)
    {
        edi.archiveTexto(idTexto, texto, titulo);
    }
}