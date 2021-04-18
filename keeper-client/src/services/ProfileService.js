import { AppState } from '../AppState'
import { api } from './AxiosService'

class ProfilesService {
  async GetProfileById(id) {
    const res = await api.get(`api/profiles/${id}`)
    AppState.profiles = res.data
  }

  async getVaultsByProfileId(id) {
    const res = await api.get(`api/profiles/${id}/vaults`)
    AppState.profileVaults = res.data
  }

  async getKeepsByProfileId(id) {
    const res = await api.get('api/profiles/' + id + '/keeps')
    AppState.profileKeeps = res.data
  }
}

export const profilesService = new ProfilesService()
