13
3298534883329
404859259782631 1761863288277050900
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -8.7379770278930664,
    "Y": 8.9585142135620117
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404857257605856:1761863287810541700",
  "next_sibling": "404860833395539:1761863288643704300",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404859260038266:1761863288277109400",
  "component_type": "Internal_Component",
  "internal_component_type": "Interactable",
  "data": {
    "text": "Harvest Pine Tree",
    "radius": 1,
    "required_hold_time": 0.3000000119209290
  }
},
{
  "cid": 4,
  "aoid": "404859260160042:1761863288277137800",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404859260038266:1761863288277109400",
    "DefaultRenderer": "404859260220801:1761863288277152000",
    "DepletedRenderer": "404859260193926:1761863288277145700"
  }
},
{
  "cid": 5,
  "aoid": "404859260173243:1761863288277140800",
  "component_type": "Internal_Component",
  "internal_component_type": "Polygon_Collider",
  "data": {
    "make_navmesh_loop": true,
    "flip_navmesh_loop": true,
    "points": [
      {
        "X": -0.1877212524414062,
        "Y": -0.2063050270080566
      },
      {
        "X": 0.0189009904861450,
        "Y": -0.2597980499267578
      },
      {
        "X": 0.2158927917480469,
        "Y": -0.1123766899108887
      },
      {
        "X": 0.0703394412994385,
        "Y": 0.1123763322830200
      },
      {
        "X": -0.1783308982849121,
        "Y": 0.0560193061828613
      }
    ]
  }
}
