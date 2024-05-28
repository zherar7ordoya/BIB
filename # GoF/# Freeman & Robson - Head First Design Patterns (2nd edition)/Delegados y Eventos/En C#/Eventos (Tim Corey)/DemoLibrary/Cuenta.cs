using System;
using System.Collections.Generic;

namespace DemoLibrary
{
    public class Cuenta
    {
        public event EventHandler<string> TransaccionAprobadaEvent;
        public event EventHandler<SobregiroEventArgs> SobregiroEvent;

        public string CuentaNombre { get; set; }
        public decimal Balance { get; private set; }

        private readonly List<string> _transacciones = new List<string>();

        public IReadOnlyList<string> Transacciones
        {
            get { return _transacciones.AsReadOnly(); }
        }

        public bool Depositar(string nombreDeposito, decimal monto)
        {
            _transacciones.Add($"Deposited { string.Format("{0:C2}", monto) } for { nombreDeposito }");
            Balance += monto;
            TransaccionAprobadaEvent?.Invoke(this, nombreDeposito);
            return true;
        }

        public bool Pagar(string nombrePago, decimal monto, Cuenta cuentaRespaldo = null)
        {
            // Ensures we have enough money
            if (Balance >= monto)
            {
                _transacciones.Add($"Withdrew { string.Format("{0:C2}", monto) } for { nombrePago }");
                Balance -= monto;
                TransaccionAprobadaEvent?.Invoke(this, nombrePago);
                return true;
            }
            else
            {
                // We don't have enough money so we check to see if we have a backup account
                if (cuentaRespaldo != null)
                {
                    // Checks to see if we have enough money in the backup account
                    if ((cuentaRespaldo.Balance + Balance) >= monto)
                    {

                        // We have enough backup funds so transfer the amount to
                        // this account and then complete the transaction.
                        decimal montoNecesario = monto - Balance;
                        SobregiroEventArgs args = new SobregiroEventArgs(montoNecesario, "Extra Info");

                        SobregiroEvent?.Invoke(this, args);

                        if (args.CancelTransaction == true)
                        {
                            return false;
                        }

                        bool sobregiroExitoso = cuentaRespaldo.Pagar("Overdraft Protection", montoNecesario);

                        // This should always be true but we will check anyway
                        if (sobregiroExitoso == false)
                        {
                            // The overdraft failed so this transaction failed.
                            return false;
                        }

                        Depositar("Overdraft Protection Deposit", montoNecesario);

                        _transacciones.Add($"Withdrew { string.Format("{0:C2}", monto) } for { nombrePago }");
                        Balance -= monto;
                        TransaccionAprobadaEvent?.Invoke(this, nombrePago);

                        return true;
                    }
                    else
                    {
                        // Not enough backup funds to do anything
                        return false;
                    }
                }
                else
                {
                    // No backup so we fail and do nothing
                    return false;
                }
            }
        }
    }
}
