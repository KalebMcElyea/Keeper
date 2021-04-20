import { AppState } from '../AppState'
import { logger } from '../utils/Logger'
import { api } from './AxiosService'

class ProfilesService {
  async GetProfileById(profId) {
    const res = await api.get('api/profiles/' + profId)
    logger.log(res)
    AppState.profiles = res.data
  }

  async getVaultsByProfileId(id) {
    try {
      const res = await api.get('api/profiles/' + id + '/vaults')
      AppState.profileVaults = res.data
    } catch (error) {
      logger.log(error)
    }
  }

  async getKeepsByProfileId(id) {
    try {
      const res = await api.get('api/profiles/' + id + '/keeps')
      AppState.profileKeeps = res.data
    } catch (error) {
      logger.log(error)
    }
  }
}

export const profilesService = new ProfilesService()
