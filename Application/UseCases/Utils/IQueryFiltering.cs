﻿namespace Application.UseCases.Utils
{
    public interface IQueryFiltering<out TO, in TI>
    {
        TO Execute(string request, TI dto, string col);
    }
}