13
3277060046849
404857257605856 1761863287810541700
{
  "name": "PineTree",
  "local_enabled": true,
  "local_position": {
    "X": -6.9848785400390625,
    "Y": 9.4929952621459961
  },
  "local_rotation": 0,
  "local_scale": {
    "X": 1,
    "Y": 1
  },
  "previous_sibling": "404847242660738:1761863285477048700",
  "next_sibling": "404859259782631:1761863288277050900",
  "parent": "891721465828975:1761158277601834900",
  "spawn_as_networked_entity": true,
  "linked_prefab": "PineTree.prefab"
},
{
  "cid": 3,
  "aoid": "404857257950458:1761863287810620900",
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
  "aoid": "404857258072578:1761863287810649300",
  "component_type": "Mono_Component",
  "mono_component_type": "PineTree",
  "data": {
    "Interactable": "404857257950458:1761863287810620900",
    "DefaultRenderer": "404857258126586:1761863287810661900",
    "DepletedRenderer": "404857258108698:1761863287810657700"
  }
},
{
  "cid": 5,
  "aoid": "404857258085951:1761863287810652400",
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
