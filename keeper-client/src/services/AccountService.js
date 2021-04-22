import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class AccountService {
  async getAccount() {
    try {
      const res = await api.get('/account')
      AppState.account = res.data
    } catch (err) {
      logger.error('HAVE YOU STARTED YOUR SERVER YET???', err)
    }
  }

  async getVaultsByAccountId() {
    try {
      const res = await api.get('/account/vaults')
      AppState.accountVaults = res.data
    } catch (error) {
      logger.log('Vaults by account')
    }
  }
}

export const accountService = new AccountService()
